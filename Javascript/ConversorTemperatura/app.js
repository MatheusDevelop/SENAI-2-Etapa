const toFaren = (c)=> {return (c*1.8)+32 }
const toCelsius = (f)=> {return (f-32)/1.8 }

const showFaren = ()=>{
    let value = document.getElementById("toFarenInput").value;
    let el = document.getElementById("show");
    el.innerHTML = `${toFaren(value)}Fº`;
    document.getElementById("toFarenInput").value = "";
}

const showCelsius = ()=>{
    let value = document.getElementById("toCelsiusInput").value;
    let el = document.getElementById("show");
    el.innerHTML = `${toCelsius(value)}Cº`;
    document.getElementById("toCelsiusInput").value = "";
}