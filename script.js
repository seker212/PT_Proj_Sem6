//do rysowania
const canvas = document.querySelector('canvas');
const ctx = canvas.getContext('2d');

canvas.width = 1000;
canvas.height = 500;

const cw = canvas.width;
const ch = canvas.height;



function table() {
    ctx.fillStyle = 'black'
    ctx.fillRect(0, 0, cw, ch);

    ctx.fillStyle = 'green';
    ctx.fillRect(250, 125, 500, 250);

}



//6 buttonow do zagran
//pobranie przycisku
const btn = document.querySelector('button');

//nadanie akcji do przycisku
btn.addEventListener('click', function(){
//akcja wywolana przyciskiem
console.log('Click');
})




//table()
