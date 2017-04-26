export class Category { 

    public id:any;
    
    public name:string;

    public static fromJSON(data: { name:string }): Category {

        let category = new Category();

        category.name = data.name;

        return category;
    }
}
