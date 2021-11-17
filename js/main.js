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
	
	sendSnapShot(dataURI);
}


// Manda a foto para ser salva na pasta "Fotos" e a mostra para o usuario
function sendSnapShot(base64){
    var request = new XMLHttpRequest();
    request.open('POST', 'fotos.php', true);
    request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded; charset=UTF-8');
    request.onload = function() {

            if (request.status >= 200 && request.status < 400) {
                //Colocar o caminho da imagem no SRC
                var data = JSON.parse(request.responseText);
    
                //verificar se houve erro
                if(data.error){
                    alert(data.error);
                    return false;
                }
    
                //Coloca o base64 no IMG e atribui o caminho para o link
                document.querySelector("#foto").setAttribute("src", base64);
                document.querySelector("#caminhoImagem a").setAttribute("href", data.img);
                document.querySelector("#caminhoImagem a").innerHTML = data.img.split("/")[1];
            } else {
				toastr["error"]("Erro ao salvar. Tipo:" + request.status, "ERRO");
            }
        };
    
        request.onerror = function() {
            toastr["error"]( "Erro ao salvar.", "ERRO");
        }

		document.getElementById("cam").style.display = "none";
        request.send("base_img="+base64);
}


// Para testes de tamanho
function forTests(c){
	var i = (document.getElementById("TesteInp")).value;
	var s = "placeholders/placeholder"+i+".png";

	// Para testar o video
	if(c==1){
		document.getElementById("cam").style.display = "block";
		document.getElementById("foto_display").style.display = "none";

		document.querySelector("#teste").setAttribute("src", s);
	}
	// Para testar a imagem
	else if(c==2){
		document.getElementById("cam").style.display = "none";
		document.getElementById("foto_display").style.display = "block";

		document.querySelector("#foto").setAttribute("src", s);
	}
}

