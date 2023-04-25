export interface IComment{
    id?: number,
    commentContent: string,
    username?: string,
    userId : number,
    parentId: null | string;
    hobbyArticleId: number | undefined
}