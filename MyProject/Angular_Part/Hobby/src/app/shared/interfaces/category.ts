import { ISubCategory } from './subcategory';

export interface ICategory {
       id: number,
       name: string,
       createdDate: string,
       hobbySubCategories: ISubCategory[];
}