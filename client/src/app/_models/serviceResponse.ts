export class ServiceResponse<T>  {
    data: T;
    message: string;
    success: boolean = true;
}