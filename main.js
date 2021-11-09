//<script type="text/javascript"></script>
//<input type="file" accept="image/*" capture="camera">

function setFoto(){
	document.getElementById("overlay").style.display = "block";
}

function off(){
	document.getElementById("overlay").style.display = "none";
}


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
			video.style.display = "block";
			document.getElementById("Btn_TirarFoto").style.display = "block";
		})
		.catch(function(error) {
			video.style.display = "none";
			alert("Não foi possivel acessar a camera.");
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
			console.log(request.responseText);
            console.log(request);
            if (request.status >= 200 && request.status < 400) {
                //Colocar o caminho da imagem no SRC
                var data = JSON.parse(request.responseText);
    
                //verificar se houve erro
                if(data.error){
                    alert(data.error);
                    return false;
                }
    
                //Mostrar informações
                document.querySelector("#imagemConvertida").setAttribute("src", data.img);
                document.querySelector("#caminhoImagem a").setAttribute("href", data.img);
                document.querySelector("#caminhoImagem a").innerHTML = data.img.split("/")[1];
            } else {
                alert( "Erro ao salvar. Tipo:" + request.status );
            }
        };
    
        request.onerror = function() {
            alert("Erro ao salvar. Back-End inacessível.");
        }

		document.getElementById("Btn_TirarFoto").style.display = "block";
        request.send("base_img="+base64);
}