console.log("hello ME world");
let doc = document.getElementByClassName("class1")[0];

fetch('http://api.icndb.com/jokes/random')
    .then(res => {        
        console.log('first .then()');
        return res.json();
    })
    .then(res =>{
        console.log(res.value.joke);
        console.log('second .then()');
    });

fetch('https://jsonplaceholder.typicode.com/posts')
    .then(res => {
        if (res.status == 200){
            console.log(`The response ${res.status}, ${res.statisText}`);
            return res.json();
        }
    })
    .then(res => {
        console.log(res);
    })
    .catch(err => console.log("there was an error"))
    .finally(console.log('We made it the end at the finally'));

const obj = JSON.stringify({
    title : "Alain",
    body: "Duplan",
    userId: 1,
    });

fetch('https://jsonplaceholder.typicode.com/posts', {
    method : 'POST',
    headers : {
        'content-type' : 'application/JSON'
        },
    body : obj
})
    .then(res => res.json())
    .then(res => console.log("good"));