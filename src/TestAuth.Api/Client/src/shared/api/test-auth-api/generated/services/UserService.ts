/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ApiResponseModel } from '../models/ApiResponseModel';
import type { GetCurrentUserResponseBaseApiResponseModel } from '../models/GetCurrentUserResponseBaseApiResponseModel';
import type { UpdateUserRequest } from '../models/UpdateUserRequest';
import type { UserModelListBaseApiResponseModel } from '../models/UserModelListBaseApiResponseModel';
import type { CancelablePromise } from '../core/CancelablePromise';
import type { BaseHttpRequest } from '../core/BaseHttpRequest';
export class UserService {
    constructor(public readonly httpRequest: BaseHttpRequest) {}
    /**
     * Получить информацию о текущем пользователе
     * @returns GetCurrentUserResponseBaseApiResponseModel Success
     * @throws ApiError
     */
    public getApiUserCurrent(): CancelablePromise<GetCurrentUserResponseBaseApiResponseModel> {
        return this.httpRequest.request({
            method: 'GET',
            url: '/api/user/current',
        });
    }
    /**
     * Получить список пользователей
     * @returns UserModelListBaseApiResponseModel Success
     * @throws ApiError
     */
    public postApiUserUsers(): CancelablePromise<UserModelListBaseApiResponseModel> {
        return this.httpRequest.request({
            method: 'POST',
            url: '/api/user/users',
        });
    }
    /**
     * Изменить данные пользователя
     * @param requestBody
     * @returns ApiResponseModel Success
     * @throws ApiError
     */
    public postApiUserUpdate(
        requestBody?: UpdateUserRequest,
    ): CancelablePromise<ApiResponseModel> {
        return this.httpRequest.request({
            method: 'POST',
            url: '/api/user/update',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
}
