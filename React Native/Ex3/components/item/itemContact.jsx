import React from "react";
import {View, Text} from "react-native";

const Item = ({nome, style}) => {
    return (
        <Text style={style}>{nome}</Text>
    )
}

export default Item;