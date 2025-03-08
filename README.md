# cryptography
Projeto sobre criptografia simétrica, assimétrica e hash


Gerando chave privada com OpenSSL

```powershell
openssl genrsa -out rsa-private-key.pem 2048
```

Gerando chave pública a partir da chave privada com OpenSSL

```powershell
openssl rsa -in rsa-private-key.pem -pubout -out rsa-public-key.pem
```
