const html = document.documentElement;
console.log(html);

const head = html.firstChild;
console.log(head);

const body = html.lastChild;
console.log(body);

const allChildrean = body.parentElement.childNodes;
console.log(allChildrean);

allChildrean[1].nextSibling.bgColor = 'blue';

allChildrean[2].style.backgroundColor = 'green';

const button = document.getElementsByTagName('button');
console.log(button);

const divEvent = document.getElementById('divid1');
divEvent.addEventListener('click', e =>{
    e.target.style.backgroundColor = 'grey';
})

button[0].addEventListener('click', (event) =>{
    //You stop prop to prevent event from force building and trigger other events of the same type in const nodes
    event.stopPropagation
    //event.stopImmediatePropagation
    if(button[0].style.color == 'blue')
        button[0].style.color = 'red';
    else
        button[0].style.color = 'blue';
    console.log('You pressed the button!');
    console.log(event);
    event.toElement.outerText = 'DO NOT CLICK ME'
})

const ul = document.getElementsByTagName('ul')[0];
console.log(ul);

const lis = ul.childNodes;
console.log(lis);

for (li of lis){
    li.addEventListener('click', e =>{
        e.target.remove();
    });
}

const form = document.getElementsByTagName('form')[0];
form.addEventListener('submit', e => {
    e.preventDefault
    value = form.toDoText.value;
    console.log(value);
    ul.innerHTML += `<li>${value}</li>`;

    for (li of lis){
        li.addEventListener('click', e =>{
            e.target.remove();
        })};
    
})