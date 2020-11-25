import React from "react";
import {View, StyleSheet, Button} from "react-native";
//API baixada de expo.io -> API Reference, para transformar texto em voz.
import * as Speech from 'expo-speech';

const TextSpeech = () => {
    
    const speak = () => {
        Speech.speak("Você clicou em mim.");
    }

    return (
        <View style={styles.container}>
            <Button title="Pressione para falar" onPress={() => speak()} />
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

export default TextSpeech;