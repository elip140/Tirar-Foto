// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//<script type="text/javascript"></script>
//<input type="file" accept="image/*" capture="camera">

/*function setFoto(){
	document.getElementById("overlay").style.display = "block";
}

function off(){
	document.getElementById("overlay").style.display = "none";
}*/


function loadCamera(){
	var video = document.querySelector("#webCam");
		//As opções para o funcionamento correto no iOS
		video.setAttribute('autoplay', '');
	    video.setAttribute('muted', '');
	    video.setAttribute('playsinline', '');
	
	//Verifica se o navegador pode capturar mídia
	if (navigator.mediaDevices.getUserMedia) {
		navigator.mediaDevices.getUserMedia({audio: false, video: {facingMode: 'user'}})
		.then( function(stream) {
			//Definir o elemento vídeo a carregar o capturado pela webcam
			video.srcObject = stream;

			// Mostra a camera
			document.getElementById("cam").style.display = "block";
			document.getElementById("aviso").style.display = "none";
		})
		.catch(function(error) {
			document.getElementById("cam").style.display = "none";
			document.getElementById("aviso").style.display = "block";
			toastr["error"]("Não foi possivel acessar a camera.", "ERRO");
		});
	}
	
}

function takeSnapShot(){
	var video = document.querySelector("#webCam");
	
	var canvas = document.createElement('canvas');
	canvas.width = video.videoWidth;
	canvas.height = video.videoHeight;
	var ctx = canvas.getContext('2d');
	
	//Desenhando e convertendo as dimensões
	ctx.drawImage(video, 0, 0, canvas.width, canvas.height);
	
	//Criando o JPG
	var dataURI = canvas.toDataURL('image/jpeg'); //O resultado é um BASE64 de uma imagem.
	
	document.querySelector("#foto").setAttribute("src", dataURI);
	document.querySelector("#fotoBase64").setAttribute("value", dataURI.replace("data:image/png;base64,", ""));
}
