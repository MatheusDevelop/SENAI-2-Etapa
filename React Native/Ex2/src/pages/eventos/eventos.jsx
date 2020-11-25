import React from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';

//Coloque o navigation no construtor.
const Eventos = ({navigation}) => {
  return (
    <View style={styles.container}>
      <Text>Eventos</Text>
      {/*Ao clicar no botão, vai para a página com o nome especificado.*/}
      <Button 
        title="Detalhes do Evento"
        //Você também pode passar parâmetros para o nome da screen.
        onPress={() => navigation.navigate("DetalhesEvento", {
            id: 1,
            nome: "Evento React Native"
        })}
      />
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

export default Eventos;