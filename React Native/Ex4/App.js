import React from 'react';
import {Button, View, Text, StyleSheet} from "react-native";

import AsyncStorage from '@react-native-async-storage/async-storage';

import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { createDrawerNavigator } from '@react-navigation/drawer';

import Login from "./pages/login/login";
import Home from "./pages/home/home";
import Timeline from "./pages/timeline/timeline";

const Drawer = createDrawerNavigator();
const Stack = createStackNavigator();

const Logout = ({navigation}) => {
  const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor: '#333',
      alignItems: 'center',
      justifyContent: 'center',
    }
  });

  return (
    <View style={styles.container}>
      <Text style={{color: "white", marginBottom: 20}}>Tem certeza de que quer sair?</Text>
      <Button title="Sair" onPress={() => {
        //Remove o token e direciona o usuário para o login.
        AsyncStorage.removeItem("jwt");
        navigation.push("Login");
      }}></Button>
    </View>
  )
}

const Autenticado = () => {
  //Aqui não pode colocar dentro de um NavigationContainer, por que um NavigationContainer não pode ficar dentro de outro.
  return (
    <Drawer.Navigator initialRouteName="Home">
      <Drawer.Screen name="Home" component={Home}/>
      <Drawer.Screen name="Logout" component={Logout}/>
    </Drawer.Navigator>
  )
}

export default function App() {
  return (
    <NavigationContainer>
      {/*Este headerShown faz com que aquela barra com título não exista, por que na página de Login fica feio.*/}
      <Stack.Navigator screenOptions={{headerShown: false}}>
        <Stack.Screen name="Login" component={Timeline} />
        {/*Quando o usuário estiver autenticado, renderizará o componente Autenticado, que possibilitará ao usuário ir para outras páginas. Se ele não estiver autenticado, só poderá ir para o Login.*/}
        <Stack.Screen name="Autenticado" component={Autenticado} />
      </Stack.Navigator>
    </NavigationContainer>
  );
}