import React, {useState} from 'react';
import { StyleSheet, Text, View, TextInput, TouchableHighlight } from 'react-native';

//View é um container onde pode ser adicionados estilos, flexbox, ações, etc, semelhante a uma div em HTML.
//Não precisamos de event.target.value, pois aqui, diferente do React, tem a ação OnChangeText.
/*
  Flexbox: 
  Em RN, quando se dá display flex, a direction por padrão fica column ao invés de row.
  Também parece que todo pai já vem definido com display flex.
*/

export default function App() {
  const [email, setEmail] = useState("Email"); //Iniciamos com esse valor pois será o placeholder.
  const [senha, setSenha] = useState("Senha");

  const entrar = () => {
    alert(`Email: ${email}\nSenha: ${senha}`)
  }

  return (
    <View style={styles.container}>
      <Text style={styles.titulo}>Faça login para prosseguir.</Text>
      <TextInput style={styles.form} value={email} onChangeText={text=>setEmail(text)}/>
      <TextInput style={styles.form} value={senha} onChangeText={text=>setSenha(text)}/>
      <TouchableHighlight onPress={entrar}>
        <View style={{width: 75, borderWidth: 1, borderColor: "magenta", alignItems: "center", marginTop: 10}}>
          <Text style={{color: "magenta", padding: 3}}>Entrar</Text>
        </View>
      </TouchableHighlight>
    </View>
  );
}

//Quando quiser um estilo mais complexo, ou que pode ser usado em mais de um elemento, coloque-o aqui.
//Os nomes dos estilos (padding, margin) são iguais aos do CSS, afinal, é javascript.
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
    width: 250,
    marginBottom: 10,
    color: "magenta",
    paddingLeft: 8,
    paddingRight: 8
  }
});