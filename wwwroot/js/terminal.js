import { AttachAddon} from './node_modules/xterm-addon-attach/lib/xterm-addon-attach.js';
import { Terminal } from './node_modules/xterm/lib/xterm.js';

var term = new Terminal();
term.open(document.getElementById('terminal'));
term.write('Hello from \x1B[1;3;31mxterm.js\x1B[0m $ ')
let socket = new WebSocket("ws://localhost:3000/")
const attachAddon = new AttachAddon(socket)
term.loadAddon(attachAddon);
socket.onmessage = function (msg) {
    console.log(msg)
}
socket.onopen = function () {
    $("#start").on("click", function () {
        socket.send("dockercreate()");
    });
}