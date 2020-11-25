import React, {useState, useEffect} from "react";
import {Text, View, Image, TouchableOpacity, Button} from "react-native";
import { Camera } from 'expo-camera';

const Timeline = () => {
    const [imagem, setImagem] = useState(null);
    const [permissao, setPermissao] = useState(null);
    const [tipo, setTipo] = useState(Camera.Constants.Type.back);

    useEffect(() => {
        (async () => {
            const { status } = await Camera.requestPermissionsAsync();
            setPermissao(status === 'granted');
        })();
    }, []); 

    const tirarFoto = async () => {
        let foto = await camera.takePictureAsync();
        setImagem(foto);
    }

    const postar = async () => {
        try {
            let formData = new FormData();
            const fileURL = imagem.uri;
            const fileName = fileURL.split("/").pop();
            const ext = fileURL.split(".").pop();

            formData.append("arquivo", {
                uri: fileURL,
                name: fileName,
                type: "image/"+ext
            });

            const response = await fetch("http://192.168.1.104:5000/api/upload", {
                method: "POST",
                body: formData
            });
            const data = await response.json();

            console.log("data: " + JSON.stringify(data))
        } 
        catch (error) {
            console.log(error);
        }
    }

    if (permissao === null) 
        return <View />;
    if (permissao === false) 
        return <Text>Sem acesso à câmera.</Text>;

    return (
        <View style={{ flex: 1 }}>
            <Camera style={{ flex: 1 }} type={tipo}
            ref={ref=> {
                camera=ref
            }}>
                <View
                style={{
                flex: 1,
                backgroundColor: 'transparent',
                flexDirection: 'row',
                }}>
                    <TouchableOpacity
                    style={{
                        flex: 0.1,
                        alignSelf: 'flex-end',
                        alignItems: 'center',
                    }}
                    onPress={() => {
                        setTipo(
                        tipo === Camera.Constants.Type.back
                            ? Camera.Constants.Type.front
                            : Camera.Constants.Type.back
                        );
                    }}>
                        <Text style={{ fontSize: 18, marginBottom: 10, color: 'white' }}>Gire</Text>
                    </TouchableOpacity>
                </View>
            </Camera>
            <Button title="Tirar foto" onPress={() => tirarFoto()}></Button>
            {imagem && <Image source={{uri: imagem.uri}} style={{height: 300}}/>}
            {imagem && <><Text>Deseja postar essa foto? </Text><Button title="Postar" onPress={()=>postar()}></Button></>}
        </View>
    )
}

export default Timeline;