export class Author { 

    public id:any;
    
    public name:string;

    public static fromJSON(data: { name:string }): Author {

        let author = new Author();

        author.name = data.name;

        return author;
    }
}
