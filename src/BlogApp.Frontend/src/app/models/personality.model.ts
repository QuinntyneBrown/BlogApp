export class Personality { 

    public id:any;
    
    public name: string;

    public twitter: string;

    public github: string;

    public linkedin: string;

    public bio: string;

    public static fromJSON(data: any): Personality {

        let personality = new Personality();

        personality.name = data.name;

        personality.bio = data.bio;

        personality.twitter = data.twitter;

        personality.github = data.github;

        personality.linkedin = data.linkedin;

        return personality;
    }
}
