import React, {useState, useEffect} from "react";
import {StyleSheet, Text, View, Image, TouchableOpacity, FlatList, Linking} from "react-native";

import AsyncStorage from '@react-native-async-storage/async-storage';

//Componente para renderizar os eventos da api. Esse componente é renderizado para cada item da api, e recebe como parâmetro um objeto com todos os dados de um evento.
const Item = ({nome, urlImagem, link, dataInicial, dataFinal, descricao, nomeCategoria}) => {
    return (
        <View style={styles.card}>
            <Image
                style={styles.cardImg}
                source={urlImagem}
            />
            <View style={{padding:15}}>  
                <Text style={styles.cardTitulo}>{nome}</Text>
                <Text style={styles.cardDescricao}>{descricao}</Text>
                <Text style={styles.cardDetails}>{nomeCategoria}</Text>
                <Text style={styles.cardDetails}>{dataInicial}</Text>
                <Text style={[styles.cardDetails, {marginBottom: 10}]}>{dataFinal}</Text> {/*Passando um array de styles.*/}
            </View>
            <TouchableOpacity style={{alignItems: "center", marginBottom: 20}} onPress={() => Linking.openURL(link)} /*Use isso para redirecionar para um link na web */>
                <Text style={{borderRadius: 10, backgroundColor: "magenta", padding: 5, color: "white", textAlign: "center", width: "50%"}}>Ir para o link do evento</Text>
            </TouchableOpacity>
        </View>
    )
}

const Home = () => {
    const [token, setToken] = useState("");
    const [eventos, setEventos] = useState([]);

    useEffect(() => {
        pegarToken;
        listar();
    }, []); //Se quiser chamar o useEffect toda vez que atualizar o valor de alguma variável, insira a variável neste array. Se quiser só uma vez, quando a página for inicializada, deixe-o vazio.

    const pegarToken = async () => {
        try {
            const token = await AsyncStorage.getItem("jwt");
            if(token!==null)
                setToken(token);
        } 
        catch (error) {
            console.log(error);
        }
    }

    const listar = async () => {
        try {
            const response = await fetch("http://192.168.1.104:5000/api/eventos");
            const data = await response.json();
            setEventos(data.data);
        } 
        catch (error) {
            console.log(error);
        }
    }

    //Chama o componente Item, passando os atributos.
    const renderItem = ({ item }) => (
        <Item nome={item.nome} urlImagem={item.urlImagem} link={item.link} dataInicial={item.dataInicial} dataFinal={item.dataFinal} descricao={item.descricao} nomeCategoria={item.categoria.nome} />
    );

    return (
        <View style={styles.container}>
            <Text style={{color: "white", fontSize: 20, marginBottom: 25, marginTop: 25}}>Confira os próximos eventos!</Text>
            <FlatList
                data={eventos} //Vai armazenar os dados a serem inseridos na lista.
                renderItem={renderItem} //Pega cada item de "data" e faz a ação especificada. No caso, joga na função renderItem
                keyExtractor={item => item.id} //Coloca um identificador para cada item da lista.
                style={{width: "90%", maxWidth: 350}}
            />
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#333',
        alignItems: 'center',
        justifyContent: 'center'
    },
    card: {
        borderColor: "magenta", 
        borderWidth: 1,
        borderRadius: 10, 
        marginBottom: 20
    },
    cardImg: {
        width: "100%", 
        height: 125, 
        borderTopLeftRadius: 10, 
        borderTopRightRadius: 10
    },
    cardTitulo: {
        color: "white", 
        fontWeight: "700", 
        fontSize: 20, 
        textAlign: "center"
    },
    cardDescricao: {
        color: "#DEDEDE", 
        fontWeight: "400", 
        fontSize: 15, 
        textAlign: "justify", 
        marginTop: 10, 
        marginBottom: 10,
    },
    cardDetails: {
        color: "#DEDEDE", 
        fontWeight: "100", 
        fontSize: 10, 
        textAlign: "left", 
    }
});

export default Home;