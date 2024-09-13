/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { LoginRequest } from '../models/LoginRequest';
import type { LoginResponseBaseApiResponseModel } from '../models/LoginResponseBaseApiResponseModel';
import type { CancelablePromise } from '../core/CancelablePromise';
import type { BaseHttpRequest } from '../core/BaseHttpRequest';
export class AuthService {
    constructor(public readonly httpRequest: BaseHttpRequest) {}
    /**
     * Получить токен для доступа к апи
     * @param requestBody
     * @returns LoginResponseBaseApiResponseModel Аутентификация прошла успешно
     * @throws ApiError
     */
    public postApiAuthLogin(
        requestBody?: LoginRequest,
    ): CancelablePromise<LoginResponseBaseApiResponseModel> {
        return this.httpRequest.request({
            method: 'POST',
            url: '/api/auth/login',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
}
