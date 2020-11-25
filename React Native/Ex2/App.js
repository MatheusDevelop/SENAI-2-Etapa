import 'react-native-gesture-handler';
import * as React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { createDrawerNavigator } from '@react-navigation/drawer';

import Eventos from "./src/pages/eventos/eventos";
import DetalhesEvento from "./src/pages/detalhesEvento/detalhesEvento";

const Stack = createStackNavigator();

const Tab = createBottomTabNavigator();

const Drawer = createDrawerNavigator();

export default function App() {
  return (
    //NavigationContainer = Router



    //EXEMPLO COM STACK

    //Stack.Navigator = Retornado da função createStackNavigator e funciona como um Switch.
    //Stack.Screen = Retornado da função createStackNavigator e funciona como um Route.

    //<NavigationContainer>
    //  {/*Coloque o nome da rota inicial.*/}
    //  <Stack.Navigator initialRouteName="Eventos">
    //    <Stack.Screen name="Eventos" component={Eventos}/>
    //    {/*Você também pode definir o título da página se não quiser que ele seja o nome dela, usando title. Você pode colocar algum parâmetro da rota como título.*/}
    //    <Stack.Screen name="DetalhesEvento" component={DetalhesEvento} options={({route}) => 
    //      ({title: route.params.nome,
    //        headerStyle: {
    //          backgroundColor: 'purple'
    //        },
    //    })}/>
    //  </Stack.Navigator>
    //</NavigationContainer>



    //EXEMPLO COM TAB NAVIGATION

    //<NavigationContainer>
    //  {/*Coloque o nome da rota inicial.*/}
    //  <Tab.Navigator initialRouteName="Eventos">
    //    <Tab.Screen name="Eventos" component={Eventos}/>
    //    {/*Você também pode definir o título da página se não quiser que ele seja o nome dela, usando title. Você pode colocar algum parâmetro da rota como título.*/}
    //    <Tab.Screen name="DetalhesEvento" component={DetalhesEvento}/>
    //  </Tab.Navigator>
    //</NavigationContainer>



    //EXEMPLO COM DRAWER

    <NavigationContainer>
      {/*Coloque o nome da rota inicial.*/}
      <Drawer.Navigator initialRouteName="Eventos">
        <Drawer.Screen name="Eventos" component={Eventos}/>
        {/*Você também pode definir o título da página se não quiser que ele seja o nome dela, usando title. Você pode colocar algum parâmetro da rota como título.*/}
        <Drawer.Screen name="DetalhesEvento" component={DetalhesEvento}/>
      </Drawer.Navigator>
    </NavigationContainer>
  );
}