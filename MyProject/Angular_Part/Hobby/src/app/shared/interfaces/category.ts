import { ISubCategory } from './subcategory';

export interface ICategory{
    name: string;
    subcategories: ISubCategory[];
}