import React, {useEffect, useState} from "react";
import {View, TouchableOpacity, Text, Image, Button} from "react-native";
//API baixada de expo.io -> API Reference, para pegar imagens da câmera do celular.
import { Camera } from 'expo-camera';

const CameraApi = () => {
    const [permissao, setPermissao] = useState(null);
    const [tipo, setTipo] = useState(Camera.Constants.Type.back); //Pega a câmera traseira.
    const [imagemUri, setImagemUri] = useState(null);

    useEffect(() => {
        (async () => {
            const { status } = await Camera.requestPermissionsAsync();
            //Se o status for granted, permissao = true, senão, false.
            setPermissao(status === 'granted');
        })();
    }, []);

    const tirarFoto = async () => {
        let foto = await camera.takePictureAsync();
        setImagemUri(foto.uri);
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
            {imagemUri && <Image source={{uri: imagemUri}} style={{height: 300}}/>}
            <Button title="Tirar foto" onPress={() => tirarFoto()}></Button>
        </View>
    )
}

export default CameraApi;