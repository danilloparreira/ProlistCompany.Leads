import { useEffect, useState } from 'react';
import { Card, CardContent, Typography, CardActions, Button, Avatar, CircularProgress } from '../node_modules/@mui/material/index';

export default function Invited() {
    const [leads, setLeads] = useState();

    useEffect(() => {
        populateLeads();
    }, []);

    async function populateLeads() {
        const response = await fetch('leads/status/0');
        const data = await response.json();
        setLeads(data.leads);
    }

    async function handleLeadAction(leadId, action) {
        try {
            await fetch(`/leads/${action}/${leadId}`, {
                method: 'PATCH'
            });
        } catch (error) {
            console.error('Erro ao enviar a requisição:', error);
        }
    }

    const conteudo = leads === undefined
        ? <p><CircularProgress></CircularProgress></p>
        : leads.map(lead =>
            <div key={lead.id}>
                <Card key={lead.id} sx={{ minWidth: 275 }}>
                    <CardContent>
                        <Typography variant="h5" component="div">
                            <Avatar>{lead.nome[0]}</Avatar>
                            {lead.nome}
                        </Typography>
                        <Typography variant="h5" component="div">
                            {lead.dataDeInclusao}
                        </Typography>
                        <hr></hr>
                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                            {lead.suburbio}
                        </Typography>
                        <Typography variant="body2">
                            {lead.categoria}
                        </Typography>
                        <Typography variant="body2">
                            Job ID: {lead.identificador}
                        </Typography>
                        <Typography variant="body2">
                            ${lead.preco} Lead invitation
                        </Typography>
                        <hr></hr>
                        <Typography variant="body2">
                            {lead.telefone}
                        </Typography>
                        <Typography variant="body2">
                            {lead.email}
                        </Typography>
                        <Typography variant="body2">
                            {lead.descricao}
                        </Typography>
                    </CardContent>
                    <CardActions>
                        <Button size="small" onClick={() => handleLeadAction(lead.id, 'aceitar')}>Accept</Button>
                        <Button size="small" onClick={() => handleLeadAction(lead.id, 'recusar')}>Decline</Button>
                    </CardActions>
                </Card>
                <br></br>
            </div>
        )

    return conteudo;
}
