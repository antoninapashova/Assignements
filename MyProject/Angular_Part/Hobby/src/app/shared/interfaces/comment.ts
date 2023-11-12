export interface IComment {
    id: number | null,
    commentContent: string,
    username?: string,
    userId: number,
    parentId: null | number;
    hobbyArticleId: number | undefined
}