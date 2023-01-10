import { IHobby } from "./hobby-article";

export interface IUser{

    username: string;
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    hobbies: IHobby[];
}