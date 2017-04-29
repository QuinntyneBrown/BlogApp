import { Author } from "./author.model";
import { Tag } from "./tag.model";
import { Category } from "./category.model";

export class Article {

    public id: any;

    public name: string;

    public slug: string;

    public published: string;

    public featuredImageUrl: string;

    public title: string;

    public htmlContent: string;

    public author: Author;

    public tags: Array<Tag> = [];

    public categories: Array<Category> = [];

    public static fromJSON(data: any): Article {

        let article = new Article();

        article.name = data.name;

        article.featuredImageUrl = data.featuredImageUrl;

        article.slug = data.slug;

        article.title = data.title;

        article.author = data.author;

        article.htmlContent = data.htmlContent;

        article.tags = data.tags;

        article.published = data.published;

        article.categories = data.categories;
        
        return article;
    }
}