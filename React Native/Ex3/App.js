import 'react-native-gesture-handler';
import * as React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import Contatos from "./pages/contacts/contacts";
import TextSpeech from "./pages/speech/speech";
import Localizacao from "./pages/localizacao/localizacao";
import Camera from "./pages/camera/camera";

const Tab = createBottomTabNavigator();

export default function App() {
  return (
    <NavigationContainer>
      <Tab.Navigator>
        <Tab.Screen name="Contatos" component={Contatos} />
        <Tab.Screen name="Speech" component={TextSpeech} />
        <Tab.Screen name="Localizacao" component={Localizacao} />
        <Tab.Screen name="CameraApi" component={Camera} />
      </Tab.Navigator>
    </NavigationContainer>
  );
}