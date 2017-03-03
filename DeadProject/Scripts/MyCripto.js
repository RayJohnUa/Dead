var rsa = new System.Security.Cryptography.RSACryptoServiceProvider(2048);

var pablicKey;
var privateKey;

var isKeyReady = false;

function generateKeys() {
    isKeyReady = true;
    pablicKey = rsa.ToXmlString(false);
    privateKey = rsa.ToXmlString(true);

    console.log("privateKey \n" + privateKey);
    console.log("pablicKey \n" + pablicKey);
}

$(function () {
    
});