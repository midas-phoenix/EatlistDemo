import { Injectable, Component, OnInit, OnDestroy, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import { Subscription } from 'rxjs/Subscription';

import { OidcSecurityService, OpenIDImplicitFlowConfiguration } from 'angular-auth-oidc-client';

@Injectable()
export class AuthService implements OnInit, OnDestroy {
    [x: string]: any;
    isAuthorizedSubscription: Subscription;
    isAuthorized: boolean;

    constructor(public oidcSecurityService: OidcSecurityService,
        private http: HttpClient,
        @Inject('ORIGIN_URL') originUrl: string,
        @Inject('IDENTITY_URL') identityUrl: string
    ) {
        const openIdImplicitFlowConfiguration = new OpenIDImplicitFlowConfiguration();
        openIdImplicitFlowConfiguration.stsServer = identityUrl;
        openIdImplicitFlowConfiguration.redirect_url = originUrl + 'callback';
        openIdImplicitFlowConfiguration.client_id = 'ng2';
        openIdImplicitFlowConfiguration.response_type = 'id_token token';
        openIdImplicitFlowConfiguration.scope = 'openid profile apiApp';
        openIdImplicitFlowConfiguration.post_logout_redirect_uri = originUrl + 'home';
        openIdImplicitFlowConfiguration.forbidden_route = '/forbidden';
        openIdImplicitFlowConfiguration.unauthorized_route = '/unauthorized';
        openIdImplicitFlowConfiguration.auto_userinfo = true;
        openIdImplicitFlowConfiguration.log_console_warning_active = true;
        openIdImplicitFlowConfiguration.log_console_debug_active = true;
        openIdImplicitFlowConfiguration.max_id_token_iat_offset_allowed_in_seconds = 10;
        openIdImplicitFlowConfiguration.silent_renew=true;

        //const authWellKnownEndpoints = new AuthWellKnownEndpoints();
        //authWellKnownEndpoints.setWellKnownEndpoints(this.oidcConfigService.wellKnownEndpoints);

        this.oidcSecurityService.setupModule(openIdImplicitFlowConfiguration);
        console.log('module setup at 34 is ' + this.oidcSecurityService.moduleSetup);
        if (this.oidcSecurityService.moduleSetup) {
            this.doCallbackLogicIfRequired();
            console.log('module setup is true');
        } else {
            this.oidcSecurityService.onModuleSetup.subscribe(() => {
                console.log('module setup is false');
                this.doCallbackLogicIfRequired();
            });
        }
    }

    ngOnInit() {
        this.isAuthorizedSubscription = this.oidcSecurityService.getIsAuthorized().subscribe(
            (isAuthorized: boolean) => {
                this.isAuthorized = isAuthorized;
            });
    }

    ngOnDestroy(): void {
        this.isAuthorizedSubscription.unsubscribe();
        this.oidcSecurityService.onModuleSetup.unsubscribe();
    }

    getIsAuthorized(): Observable<boolean> {
        return this.oidcSecurityService.getIsAuthorized();
    }

    login() {
        console.log('start login');
        this.oidcSecurityService.authorize();
    }

    refreshSession() {
        console.log('start refreshSession');
        this.oidcSecurityService.authorize();
    }

    logout() {
        console.log('start logoff');
        this.oidcSecurityService.logoff();
    }

    private doCallbackLogicIfRequired() {
        if (typeof location !== "undefined" && window.location.hash) {
            this.oidcSecurityService.authorizedCallback();
        }
    }

    get(url: string): Observable<any> {
        return this.http.get<any>(url, { headers: this.getHeaders() });
    }

    put(url: string, data: any): Observable<any> {
        const body = JSON.stringify(data);
        return this.http.put<any>(url, body, { headers: this.getHeaders() });
    }

    delete(url: string): Observable<any> {
        return this.http.delete<any>(url, { headers: this.getHeaders() });
    }

    post(url: string, data: any): Observable<any> {
        const body = JSON.stringify(data);
        return this.http.post<any>(url, body, { headers: this.getHeaders() });
    }

    private getHeaders() {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json');
        return this.appendAuthHeader(headers);
    }

    private appendAuthHeader(headers: HttpHeaders) {
        const token = this.oidcSecurityService.getToken();

        if (token === '') return headers;

        const tokenValue = 'Bearer ' + token;
        return headers.set('Authorization', tokenValue);
    }
}