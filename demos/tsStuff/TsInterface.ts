interface Person{
    name :string;
    age : number;
}

class Zombie{
    static victims: number;
    constructor(public birthName:string){
        
    }
}

export { Person, Zombie };