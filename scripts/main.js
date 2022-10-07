// セル1マスのサイズ
const CELL_SIZE = 8;

// カラーリスト
const COLOR_LIST = [
    '#f5f5f5',  // null(0)
    '#00ff7f',  // player(1)
    '#d2691e',  // obstacle(2)
    '#00bfff',  // blue(3)
];

// フィールド
let width;
let height;
let cells_data = new Array();

// システム
let canvas;
let ctx;

// プレイヤー
let pos_x;
let pos_y;


window.onload = function ()
{
    canvas = document.getElementById('field');
    ctx = canvas.getContext('2d');

    width = Math.floor(canvas.width / CELL_SIZE);
    height = Math.floor(canvas.height / CELL_SIZE);

    canvas.addEventListener('click', onClick, false);

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

    pos_x = Math.floor(Math.random() * width);
    pos_y = Math.floor(Math.random() * height);
    cells_data[pos_y][pos_x] = 1;

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


// キー入力
document.addEventListener('keydown', function (e) {
    cells_data[pos_y][pos_x] = 0;

    if (e.code == 'ArrowUp' && pos_y > 0 && cells_data[pos_y - 1][pos_x] != 2) {
        pos_y--;
    }
    else if (e.code == 'ArrowDown' && pos_y < height - 1 && cells_data[pos_y + 1][pos_x] != 2) {
        pos_y++;
    }
    else if (e.code == 'ArrowLeft' && pos_x > 0 && cells_data[pos_y][pos_x - 1] != 2) {
        pos_x--;
    }
    else if (e.code == 'ArrowRight' && pos_x < width - 1 && cells_data[pos_y][pos_x + 1] != 2) {
        pos_x++;
    }

    cells_data[pos_y][pos_x] = 1;
    reDraw();

	return false;
});


// フィールドがクリックされたとき
function onClick(e) {
    let pos_x = e.clientX - canvas.offsetLeft;
    let pos_y = e.clientY - canvas.offsetTop;
    let idx_x = Math.floor(pos_x / CELL_SIZE);
    let idx_y = Math.floor(pos_y / CELL_SIZE);

    if (cells_data[idx_y][idx_x] == 0) {
        cells_data[idx_y][idx_x] = 2;
    }
    else if (cells_data[idx_y][idx_x] == 2) {
        cells_data[idx_y][idx_x] = 0;
    }

    drawCell(idx_x, idx_y);
}