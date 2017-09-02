module Swu {
    export interface Forum{
        id: string;
        name: string;
        shortDescription: string;
        fullDescription: string;
        imageUrl: string;
        numberOfViews: number;
        price: number;
        createdDate: Date;
        creatorName: string;
    }
    export interface Comment {
        id: number;
        description: string;
        creatorName: string;
        createImageUrl: string;
    }
    export interface ForumAndComments{
        forum: Forum;
        comments: Comment[];
    }
}