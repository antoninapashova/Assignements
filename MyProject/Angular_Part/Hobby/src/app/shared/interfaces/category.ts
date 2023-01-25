import { ISubCategory } from './subcategory';
export interface ICategory{ 
       id: number,
       name: string,
       hobbySubCategories: ISubCategory[];
}