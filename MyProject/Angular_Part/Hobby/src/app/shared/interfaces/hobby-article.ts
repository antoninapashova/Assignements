import { IPhoto } from './photo';
import { ITag } from "./tag";

export interface IHobby {
    id: number,
    title: string;
    description: string;
    likes: number;
    hobbySubcategoryId: number,
    hobbySubCategory: string | undefined,
    username: string,
    userId: number,
    hobbyPhoto: IPhoto[],
    tags: ITag[],
}