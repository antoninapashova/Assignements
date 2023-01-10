import { ITag } from "./tag";

export interface IHobby{
    title: string;
    description: string;
    subcategory: string;
    tags: ITag[]
}