import React, {useState} from "react";
import {StyleSheet, Text, View, TextInput, TouchableHighlight} from "react-native";

//Funciona como o localStorage dos navegadores. Baixado da API Reference do expo.io. Lá tem muitas coisas como geolocalização, bateria, sensores, etc.
import AsyncStorage from '@react-native-async-storage/async-storage';

const Login = ({navigation}) => {
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");

    //Promise -> Um Promise (de "promessa") representa um valor que pode estar disponível agora, no futuro ou nunca.
    
    //async/await -> async/await é um jeito mais fácil de utilizar uma Promise. Uma função assíncrona retorna uma Promise (Assíncrona é de "fora de sincronia".. não é igual as funções normais que são síncronas, que vai executando linha por linha e resolvendo as Promises em segundo plano). Você utiliza o await em uma função assíncrona, para esperar a resolução da Promise (await só funciona em funções assíncronas). Exemplo:
    /*
        async function get() {
            //Sem o await, o valor de response seria uma Promise. Com o await, response não recebe um valor e nenhum código abaixo dessa linha será executado enquanto a promise do fetch não for resolvida. Portanto, outras funções podem estar sendo executadas no mesmo momento. Por que isso é útil? Por exemplo.. você deu um fetch, e você precisa utilizar a resposta desse fetch em outro fetch. Só que talvez a resposta do primeiro demore a chegar, pois o fetch é executado mas a promise ainda não foi resolvida. Chega-se então no segundo fetch, que depende do primeiro, mas não existe um valor ainda, pois a promise do primeiro ainda não foi resolvida. Com async/await, por exemplo, você pode ter vários fetchs rodando ao mesmo tempo, um não interferirá no outro, e você terá os resultados no tempo certo. Só lembrando que as Promises, sincronicamente, são chamadas e são resolvidas em segundo plano, em outro thread, enquanto o resto do código roda.
            const response = await fetch(url);
            const data = await response.json();

            //Se você colocar esse console.log, será printado a data da response.
            console.log(data);

            //Se você retornar um valor, o valor retornado será uma promise, pois como já dito, toda função async retorna uma Promise.
            return await response.json();
        }

        Para pegar o valor retornado de uma função async resolva a promise:
        get().then(value => console.log(value));

        Como nas funções async você não colocará o .catch(), você envolve ela em um bloco try/catch.
    */

    const salvarToken = async (token) => {
        try {
            //Salva o token no AsyncStorage.
            await AsyncStorage.setItem("jwt", token);
        } 
        catch (error) {
            console.log(error);
        }
    }

    const logar = () => {
        //Aqui no mobile não vai funcionar a url iniciando com localhost, já que a api não está no celular. Você terá que pegar com o IP da rede, utilizando o comando "ipconfig" no cmd. Copie o campo "Endereço IPv4". Você também precisa trocar "localhost" pelo ip no launchSettings.json da API. Agora, todos aparelhos conectados nessa rede poderão acessar a API.
        fetch("http://192.168.1.104:5000/api/account/login", {
            method: "POST",
            headers: {
                "content-type": "application/json"
            },
            body: JSON.stringify({
                email: email,
                senha: senha
            })
        })
        .then(response => response.json())
        .then(data => {
            //Se o usuário não estiver cadastrado, o status será um 404.
            if(data.status!==404) {
                salvarToken(data.token)
                navigation.push("Autenticado");
            }
            else 
                alert("Email ou senha inválidos!");
        })
        .catch(err => console.log(err));
    }

    return (
        <View style={styles.container}>
            <Text style={styles.titulo}>Faça login para prosseguir.</Text>
            <TextInput style={styles.form} value={email} onChangeText={text=>setEmail(text)} placeholder="Email" placeholderTextColor="#666"/>
            <TextInput style={styles.form} value={senha} onChangeText={text=>setSenha(text)} placeholder="Senha" placeholderTextColor="#666" secureTextEntry={true}/>
            <TouchableHighlight onPress={logar}>
                <View style={{width: 75, borderWidth: 1, borderColor: "magenta", alignItems: "center", marginTop: 10, borderRadius: 5}}>
                    <Text style={{color: "magenta", padding: 3}}>Entrar</Text>
                </View>
            </TouchableHighlight>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#333',
        alignItems: 'center',
        justifyContent: 'center',
      },
      titulo: {
        color: "#DEDEDE",
        fontSize: 20,
        fontWeight: "bold",
        marginBottom: 40
      },
      form: {
        borderColor: "#DEDEDE",
        borderWidth: 1,
        borderRadius: 10,
        width: "85%",
        marginBottom: 10,
        color: "magenta",
        paddingLeft: 8,
        paddingRight: 8
      }
});

export default Login;