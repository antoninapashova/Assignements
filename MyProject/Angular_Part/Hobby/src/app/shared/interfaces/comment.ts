export interface IComment{
    id?: number,
    commentContent: string,
    username?: string,
    userId : number,
    hobbyArticleId: number | undefined
}