# Tirar-Foto
Pagina Web com o objetivo de tirar uma foto e manda-la

TODO:
 - Fazer salvamento de dados em .NET/DOTNET
 - Inserir avisos de compatibilidade com navegadores por conta do getUserMedia
 - Avisar em caso de HTTPS
 - Usar notificação via toastr (codeseven.github.io/toastr/)


Pagina HTML5 com JS:
- Pede acesso a camera
- Tira uma foto
- Mostra a foto
- Manda a foto com id de usuario

Funções:
- main.js:
    - loadCamera()
    Verifica e ativa o uso da camera no navegador 
- Fotos.php
Salva as fotos mandadas pelo main.js na pasta "fotos"