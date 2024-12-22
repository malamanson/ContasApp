import React from 'react';
import { View, Text, StyleSheet } from 'react-native';

const ConfiguracoesScreen = () => {
    return (
        <View style={styles.container}>
            <Text style={styles.title}>Configurações</Text>
            {/* Implementar lógica para preferências do app */}
        </View>
    );
};

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
    },
    title: {
        fontSize: 24,
        fontWeight: 'bold',
    },
});

export default ConfiguracoesScreen;
