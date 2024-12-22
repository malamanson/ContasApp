import React, { useState } from 'react';
import { View, Text, FlatList, TouchableOpacity, StyleSheet } from 'react-native';

const ContasScreen = ({ navigation }) => {
    const [contas, setContas] = useState([
        { id: '1', nome: 'Conta Corrente', saldo: 1000 },
        { id: '2', nome: 'Poupança', saldo: 5000 },
    ]);

    return (
        <View style={styles.container}>
            <Text style={styles.title}>Gerenciar Contas</Text>
            <FlatList
                data={contas}
                keyExtractor={(item) => item.id}
                renderItem={({ item }) => (
                    <View style={styles.card}>
                        <Text style={styles.cardText}>{item.nome}</Text>
                        <Text style={styles.cardText}>Saldo: R${item.saldo}</Text>
                    </View>
                )}
            />
            <TouchableOpacity
                style={styles.addButton}
                onPress={() => navigation.navigate('AddConta')}
            >
                <Text style={styles.addButtonText}>Adicionar Conta</Text>
            </TouchableOpacity>
        </View>
    );
};

const styles = StyleSheet.create({
    container: {
        flex: 1,
        padding: 20,
    },
    title: {
        fontSize: 24,
        fontWeight: 'bold',
        marginBottom: 10,
    },
    card: {
        backgroundColor: '#eee',
        padding: 15,
        borderRadius: 8,
        marginBottom: 10,
    },
    cardText: {
        fontSize: 16,
    },
    addButton: {
        backgroundColor: '#4CAF50',
        paddingVertical: 15,
        borderRadius: 5,
        alignItems: 'center',
    },
    addButtonText: {
        color: '#fff',
        fontSize: 16,
        fontWeight: 'bold',
    },
});

export default ContasScreen;