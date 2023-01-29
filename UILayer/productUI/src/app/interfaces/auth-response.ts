export interface AuthResponse {
    IsAuthSuccessful: boolean,
    ErrorMessage: boolean,
    Token: string,
    Expires?: Date
}
