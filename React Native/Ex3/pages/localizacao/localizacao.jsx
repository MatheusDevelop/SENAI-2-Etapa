import React, {useEffect, useState} from "react";
import {View, StyleSheet, Text} from "react-native";
//API baixada de expo.io -> API Reference, para pegar localização do celular.
import * as Location from 'expo-location';

const Localizacao = () => {
    const [localizacao, setLocalizacao] = useState([]);
    const [errorMsg, setErrorMsg] = useState("");

    useEffect(() => {
        (async () => {
            let { status } = await Location.requestPermissionsAsync();
            if (status !== 'granted') {
                setErrorMsg('Permissão negada');
            }

            //Pega localização
            let location = await Location.getCurrentPositionAsync({});
            setLocalizacao(location);
        })();
    }, []);

    let text = '...';
    if (errorMsg)
        text = errorMsg;
    else if (localizacao) 
        text = JSON.stringify(localizacao);

    return (
        <View style={styles.container}>
            <Text style={{color: "magenta", textAlign: "center"}}>{text}</Text>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor: '#555',
      alignItems: 'center',
      justifyContent: 'center',
    }
});

export default Localizacao;