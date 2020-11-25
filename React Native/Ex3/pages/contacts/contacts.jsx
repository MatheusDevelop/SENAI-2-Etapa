import React, {useEffect, useState} from "react";
import {View, Text, StyleSheet, FlatList} from "react-native";
//API baixada de expo.io -> API Reference, para pegar contatos do celular.
import * as Contacts from 'expo-contacts';

import Item from "../../components/item/itemContact";

const Contatos = () => {
    const [contatos, setContatos] = useState([]);
    useEffect(() => {
        (async () => {
            
            //Pede permissão do usuário para que o aplicativo possa pegar informações da agenda. Enquanto não houver uma resposta (await), nenhuma linha abaixo será lida.
            const { status } = await Contacts.requestPermissionsAsync();

            //Se a permissão foi concedida...
            if (status === 'granted') {

                //Pega todos os contatos
                const { data } = await Contacts.getContactsAsync({
                    fields: [Contacts.Fields.Emails],
                });
        
                //Se tiver contatos cadastrados...
                if (data.length > 0) {
                    setContatos(data);
                }
            }
        })();
    }, []);

    const renderItem = ({item}) => {
        return (
            <Item style={styles.item} nome={item.name}/>
        )
    }

    return (
        <View style={styles.container}>
            <FlatList
                data={contatos}
                renderItem={renderItem}
                keyExtractor={item => item.id}
            />
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor: '#555',
      alignItems: 'center',
      justifyContent: 'center',
    },
    item: {
        color: "magenta",
        backgroundColor: "#333",
        padding: 10,
        margin: "auto",
        marginVertical: 5
    }
});

export default Contatos;