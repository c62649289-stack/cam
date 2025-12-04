let name = "Helene"
let count = 0
console.log(name)

function handleOnClick(){
 let response = await fetch("https://dog.ceo/api/breeds/image/random")
 let json = await response.json

   document.getElementById("counter").innerHTML = <img src="${json.message}" "<"
}