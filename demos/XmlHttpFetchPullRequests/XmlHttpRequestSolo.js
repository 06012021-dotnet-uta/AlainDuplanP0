console.log("Hello World");



var request = new XMLHttpRequest();
var url = "https://jsonplaceholder.typicode.com/posts"

request.open('POST', url, true);
const requestBody = JSON.stringify({
    title : "Alain",
    Body: "Duplan",
    userId: 1,
});

request.send(requestBody);

request.setRequestHeader("Content-Type", "application/json");

request.onreadystatechange = () => {
    console.log(`the ready state is => ${request.readyState}`);
    if(request.readyState == 4){//check that the request is finished
        //check that the request was successfull
        if(request.status >= 200 || request.status < 300){
            console.log(`Succesful ${request.status}`);
            console.log(`${request.responseText}`);
            console.log(`${request.response}`);
            //console.log(`${JSON.parse(request.response).value.joke}`);
        }
    }
}