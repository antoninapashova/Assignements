import { IPhoto } from './photo';
import { ITag } from "./tag";

export interface IHobby{
    id?: number,
    title: string;
    description: string;
    hobbySubcategoryId: number,
    userId: number,
    photos: IPhoto[],
    tags: ITag[]
}