export class Author { 

    public id:any;
    
    public firstname: string;

    public lastname: string;

    public static fromJSON(data: any): Author {

        let author = new Author();

        author.firstname = data.firstname;

        author.lastname = data.lastname;
        
        return author;
    }
}
