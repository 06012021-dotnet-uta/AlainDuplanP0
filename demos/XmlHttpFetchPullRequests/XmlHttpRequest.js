console.log("Hello World");

function DoIt(){
    console.log("DO It Message");
    console.log(`the ready state is => ${this.readyState}`);
}

//inst the object that will make and recieve that request
var request = new XMLHttpRequest();

//tell the request object what to do when the response is recieved
//request.onreadystate = DoIt;
request.onreadystatechange = () => {
    console.log(`the ready state is => ${request.readyState}`);
    if(request.readyState == 4){//check that the request is finished
        //check that the request was successfull
        if(request.status == 200){
            console.log('Succesfully lololol')
            console.log(`${request.responseText}`);
            console.log(`${request.response}`);
            console.log(`${JSON.parse(request.response).value.joke}`);
        }
    }
}

//open a connection
//specify the endpoint(url, controller action)
//          HTTPMethod, Full url to the endpoint,        async?
request.open('GET', "http://api.icndb.com/jokes/random", true);


//send the request
request.send();