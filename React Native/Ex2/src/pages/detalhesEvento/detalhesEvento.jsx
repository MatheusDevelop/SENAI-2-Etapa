import React from 'react';
import { StyleSheet, Text, View } from 'react-native';

//Colocamos os parâmetros recebidos da rota na Screen.
const DetalhesEvento = ({route, navigation}) => {
  //Nossos parâmetros passados pela rota.
  //Ao ativar o tabs navigation ou drawer, tire esta linha.
  //const {id, nome} = route.params;

  return (
    <View style={styles.container}>
      <Text>Detalhes evento</Text>
      {/*Tire estas linhas ao colocar tabs navigation ou drawer*/}
      {/*<Text>#: {id}</Text>*/}
      {/*<Text>Nome: {nome}</Text>*/}
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});

export default DetalhesEvento;