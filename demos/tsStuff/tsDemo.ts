import { Person, Zombie } from './TsInterface.js'

let alain:string;

alain = 'alain';
console.log(alain);

let num: number = 0;
num += 5;
console.log(num);

console.log(name);

let funReturn = function myFunc(name1:string):string{
    console.log(name1);
    return name1;
};

console.log(funReturn("calling"));

let myPerson: Person = {name : "alain", age: 22};
console.log(myPerson.name);


let myZombi = new Zombie('Carl');
console.log(myZombi.birthName);
console.log(Zombie.victims);
Zombie.victims += 5;
console.log(Zombie.victims);