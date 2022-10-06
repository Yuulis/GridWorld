// セル1マスのサイズ
const CELL_SIZE = 8;

// カラーリスト
const COLOR_LIST = [
    '#f5f5f5',  // null(0)
    '#00ff7f',  // green(1)
    '#ff4545',  // red(2)
    '#00bfff',  // blue(3)
];

// フィールド
let width;
let height;
let cells_data = new Array();

// システム
let canvas;
let ctx;


window.onload = function ()
{
    canvas = document.getElementById('field');
    ctx = canvas.getContext('2d');

    width = Math.floor(canvas.width / CELL_SIZE);
    height = Math.floor(canvas.height / CELL_SIZE);

    initialize();
};


// 初期化
function initialize() {
    step = 0;

    for (let y = 0; y < height; y++) {
        cells_data[y] = new Array();
        for (let x = 0; x < width; x++) {
            cells_data[y][x] = 0;
        }
    }

    ctx.fillStyle = '#000000';
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    reDraw();
}


// フィールド再描画
function reDraw() {
    for (let y = 0; y < height; y++) {
        for (let x = 0; x < width; x++) {
            drawCell(x, y);
        }
    }
}


// セル描画
function drawCell(x, y) {
    ctx.fillStyle = COLOR_LIST[cells_data[y][x]];
    ctx.fillRect(x * CELL_SIZE + 1, y * CELL_SIZE + 1, CELL_SIZE - 1, CELL_SIZE - 1);
}